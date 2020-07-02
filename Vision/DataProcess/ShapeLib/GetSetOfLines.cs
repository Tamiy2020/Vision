using ChoiceTech.Halcon.Control;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DataProcess.ShapeLib
{
    /// <summary>
    /// 抓一组线类
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class GetSetOfLines : BaseShape
    {

        /// <summary>
        /// 线组
        /// </summary>
        public List<Line> LineList;

        /// <summary>
        /// 最大ID
        /// </summary>
        private int maxId;

        /// <summary>
        /// 线数目
        /// </summary>
        public int CountOfLine
        {
            get { return LineList.Count; }
        }

        public GetSetOfLines()//构造函数
        {
            maxId = 1;
            LineList = new List<Line>();
        }


        /// <summary>
        /// 设置定位
        /// </summary>
        public override void SetPosition()
        {
            base.SetPosition();
            foreach (BaseShape item in LineList)
            {
                item.position_Horizontal = position_Horizontal;
                item.position_Vertical = position_Vertical;
                item.SetPosition();
            }
        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="line"></param>
        public void AddLine(Line line)
        {
            line.iD = maxId++;//分配ID
            line.name = line.iD.ToString();//分配name
            LineList.Add(line);
        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="index"></param>
        public void RemoveLine(int index)
        {
            LineList.Remove(LineList[index]);
        }

        /// <summary>
        /// 删除所有项
        /// </summary>
        public void RemoveAll()
        {
            if (LineList.Count > 0)
            {
                maxId = 1;
                LineList.Clear();
            }
        }

        /// <summary>
        /// 查
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Line GetLine(int index)
        {
            return LineList[index];
        }

        /// <summary>
        /// 获取所有线的名字
        /// </summary>
        /// <returns></returns>
        public string[] GetLinesName()
        {
            List<string> linesName = new List<string>();
            foreach (var item in LineList)
            {
                linesName.Add(item.name);
            }
            return linesName.ToArray();
        }

        public override int Measure(HObject ho_Image)//测量
        {
            foreach (var item in LineList)
            {
                item.Measure(ho_Image);
            }
            MeasureDone = true;//已测量标志为true
            return 1;
        }

        public override void DisplayDetail(HWindow_Final window)//显示详细信息
        {
            foreach (var item in LineList)
            {
                item.DisplayDetail(window);
            }
        }

        public override void DisplayResult(HWindow_Final window)//显示简单信息
        {
            foreach (var item in LineList)
            {
                item.DisplayResult(window);
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public override void Dispose()
        {
            foreach (var item in LineList)
            {
                item.Dispose();
            }
        }

        public override BaseShape GetShapePositioned()
        {
            return null;
        }
    }
}
