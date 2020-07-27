using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Rabbit.InvokeHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vision.CameraLib;

namespace Vision
{
    /// <summary>
    /// 执行管理器
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class ExecutionManager : IDisposable
    {
        /// <summary>
        /// 测量单元管理器列队
        /// </summary>
        public List<MeasureManager> listMeasureManager;

        /// <summary>
        /// IO卡
        /// </summary>
        [NonSerialized]//不序列化该字段
        private IOManager iOManager;

        public ExecutionManager(CameraManager cameraManager)
        {
            listMeasureManager = new List<MeasureManager>();
            foreach (var camera in cameraManager.listCamera)
            {
                MeasureManager measureManager = new MeasureManager(camera);
                measureManager.ImageAcqed();
                measureManager.MeasureFinish += MeasureManager_MeasureFinish;//
                listMeasureManager.Add(measureManager);
            }
            Initialize();
        }

        public ExecutionManager(CameraManager cameraManager, List<MeasureManager> measureManagers)
        {
            for (int i = 0; i < cameraManager.listCamera.Count; i++)
            {
                this.listMeasureManager = measureManagers;//赋值测量单元管理器
                this.listMeasureManager[i].camera = cameraManager.listCamera[i];//赋值测量单元管理器的相机
                this.listMeasureManager[i].ImageAcqed();
                this.listMeasureManager[i].InitData();
                this.listMeasureManager[i].MeasureFinish += MeasureManager_MeasureFinish;//挂载测量单元管理器测量完成事件
            }
            Initialize();
        }




        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            iOManager = new IOManager();
            iOManager.eventOneSignal += IOManager_eventOneSignal;
        }

        private int IOManager_eventOneSignal(int arg)
        {
            if (arg >= listMeasureManager.Count)
                return 0;
            listMeasureManager[arg].Grad();//开始一次测量
            return 0;
        }

        //测量完成
        private int MeasureManager_MeasureFinish(int bit_number, int value)
        {
            iOManager.SetOutPutData_Bit(bit_number, value);//io卡管理器发结果信号
            return 0;
        }

        public void GradAll()
        {
            foreach (var measureManager in listMeasureManager)
            {
                measureManager.Grad();
            }
        }

        public void LiveAll(bool live)
        {
            foreach (var measureManager in listMeasureManager)
            {
                measureManager.Live(live);
            }

        }

        /// <summary>
        /// 获取用以保存的数据克隆副本
        /// </summary>
        /// <returns></returns>
        public List<MeasureManager> GetMeasureManagerListClone()
        {
            List<MeasureManager> listMeasureManager = new List<MeasureManager>();
            foreach (var item in this.listMeasureManager)
            {
                listMeasureManager.Add((MeasureManager)(item as ICloneable).Clone());
            }
            return listMeasureManager;
        }


        /// <summary>
        /// 清空并新建数据
        /// </summary>
        public void ClearMUMList()
        {
            foreach (var item in listMeasureManager)
            {
                item.CreateNewMUM();
            }
        }



        /// <summary>
        /// 获取所有表格数据
        /// </summary>
        /// <returns></returns>
        private List<DataTable> GetAllDataTable()
        {
            List<DataTable> dataTables = new List<DataTable>();
            foreach (var item in listMeasureManager)
            {
                if (item.dataTable != null)
                    dataTables.Add(item.dataTable);
            }
            return dataTables;
        }

        /// <summary>
        /// 清空所有已保存测量数据
        /// </summary>
        private void ClearAllDataTables()
        {
            foreach (var item in listMeasureManager)
            {
                if (item.dataTable != null)
                    item.dataTable.Rows.Clear();
            }
        }


        /// <summary>
        /// 保存所有数据表格
        /// </summary>
        /// <param name="dataTables"></param>
        /// <param name="path"></param>
        private void SaveAllDataTable(List<DataTable> dataTables, string path)
        {
            IWorkbook workbook = new HSSFWorkbook();//创建一个工作簿

            for (int n = 0; n < dataTables.Count; n++)
            {
                ISheet sheet = workbook.CreateSheet(dataTables[n].TableName);//创建一个 sheet 表


                //设置列宽
                sheet.SetColumnWidth(1, 30 * 256);//名称
                sheet.SetColumnWidth(2, 30 * 256);//测量类型
                sheet.SetColumnWidth(7, 30 * 256);//时间
                sheet.SetColumnWidth(3, 15 * 256);//最小值
                sheet.SetColumnWidth(4, 15 * 256);//最大值
                sheet.SetColumnWidth(5, 15 * 256);//测量值




                IRow rowH = sheet.CreateRow(0);//创建一行
                ICell cell = null;//创建一个单元格
                ICellStyle cellStyle = workbook.CreateCellStyle();//创建单元格样式
                IDataFormat dataFormat = workbook.CreateDataFormat();//创建格式
                cellStyle.DataFormat = dataFormat.GetFormat("@");//设置为文本格式，也可以为 text，即 dataFormat.GetFormat("text");
                                                                 //设置列名
                foreach (DataColumn col in dataTables[n].Columns)
                {
                    rowH.CreateCell(col.Ordinal).SetCellValue(col.Caption);//创建单元格并设置单元格内容
                    rowH.Cells[col.Ordinal].CellStyle = cellStyle;//设置单元格格式
                }

                //表格样式
                IFont font = workbook.CreateFont();
                font.FontName = "微软雅黑";
                font.FontHeightInPoints = 12;
                cellStyle.SetFont(font);
                cellStyle.VerticalAlignment = VerticalAlignment.Center;
                cellStyle.Alignment = HorizontalAlignment.Center;


                //写入数据
                for (int i = 0; i < dataTables[n].Rows.Count; i++)
                {
                    //跳过第一行，第一行为列名
                    IRow row = sheet.CreateRow(i + 1);
                    row.Height = 350;


                    for (int j = 0; j < dataTables[n].Columns.Count; j++)
                    {
                        cell = row.CreateCell(j);
                        cell.SetCellValue(dataTables[n].Rows[i][j].ToString());
                        cell.CellStyle = cellStyle;

                    }
                }
                sheet = null;
            }
            //创建文件
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            //创建一个 IO 流
            MemoryStream ms = new MemoryStream();
            //写入到流
            workbook.Write(ms);
            //转换为字节数组
            byte[] bytes = ms.ToArray();
            file.Write(bytes, 0, bytes.Length);
            file.Flush();
            //释放资源
            bytes = null;
            ms.Close();
            ms.Dispose();
            file.Close();
            file.Dispose();
            workbook.Close();
            workbook = null;
        }



        /// <summary>
        /// 导出数据到表格
        /// </summary>
        /// <param name="path"></param>
        public void DataExport(string path)
        {
            List<DataTable> dataTables = GetAllDataTable();
            SaveAllDataTable(dataTables, path);
            ClearAllDataTables();
        }


        public void Dispose()
        {
            foreach (var item in listMeasureManager)
            {
                item.Dispose();
                item.ClearImageAcqed();
            }
        }
    }
}
