using Rabbit.InvokeHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.CameraLib;

namespace Vision
{
    /// <summary>
    /// 执行管理器
    /// </summary>
    [Serializable]//序列化标志，表示当前类的实例可以被序列化储存
    public class ExecutionManager: IDisposable
    {
        /// <summary>
        /// 测量单元管理器列队
        /// </summary>
        public List<MeasureManager> listMeasureManager = new List<MeasureManager>();
        public ExecutionManager(CameraManager cameraManager)
        {
            foreach (var camera in cameraManager.listCamera)
            {
                MeasureManager measureManager = new MeasureManager(camera);
                measureManager.MeasureFinish += MeasureManager_MeasureFinish;//
                listMeasureManager.Add(measureManager);
            }
        }

        //测量完成
        private int MeasureManager_MeasureFinish(int bit_number, int value)
        {/*
            if (value == 2)
            {
                if (listMeasureManager[bit_number].LastResult == Result.OK)
                {
                    listMeasureManager[bit_number].camera.Label_OK.BackColor = System.Drawing.Color.Green;
                    InvokeHelper.Set(listMeasureManager[bit_number].camera.Label_OK, "Text", "OK");
                }
                if (listMeasureManager[bit_number].LastResult == Result.NG)
                {
                    listMeasureManager[bit_number].camera.Label_OK.BackColor = System.Drawing.Color.Red;
                    InvokeHelper.Set(listMeasureManager[bit_number].camera.Label_OK, "Text", "NG");
                }
                if (listMeasureManager[bit_number].LastResult == Result.无料)
                {
                    listMeasureManager[bit_number].camera.Label_OK.BackColor = System.Drawing.Color.White;
                    InvokeHelper.Set(listMeasureManager[bit_number].camera.Label_OK, "Text", "WT");
                }
                InvokeHelper.Set(listMeasureManager[bit_number].camera.Label_Sum, "Text", listMeasureManager[bit_number].Sum.ToString());
                InvokeHelper.Set(listMeasureManager[bit_number].camera.Label_Num, "Text", listMeasureManager[bit_number].Num_OK.ToString());
                InvokeHelper.Set(listMeasureManager[bit_number].camera.Label_Yield, "Text", listMeasureManager[bit_number].Yield);
            }*/
            return 0;
        }

        public void GradAll()
        {
            foreach (var measureManager in listMeasureManager)
            {
                measureManager.Grad();
            }
        }

        public void  LiveAll(bool live)
        {
            foreach (var measureManager in listMeasureManager)
            {
                measureManager.Live(live);
            }
            
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
