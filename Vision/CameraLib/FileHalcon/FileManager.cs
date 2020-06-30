using ChoiceTech.Halcon.Control;
using HalconDotNet;

namespace Vision.CameraLib
{
    /// <summary>
    /// 文件相机管理器
    /// </summary>
    public class FileManager : CameraManager
    {
        /// <summary>
        /// 添加相机
        /// </summary>
        /// <param name="path"></param>
        public void AddCamera(string path)
        {
            File fileCamera = new File(

                  new HTuple[]
                {
                     new HTuple("File"),//0
                     new HTuple(0),//1
                     new HTuple(1),//2
                     new HTuple(0),//3
                     new HTuple(0),//4
                     new HTuple(0),//5
                     new HTuple(0),//6
                     new HTuple("default"),//7
                     new HTuple(-1),//8
                     new HTuple("default"),//9
                     new HTuple(1),//10
                     new HTuple("false"),//11
                     new HTuple(path),//12
                     new HTuple("default"),//13
                     new HTuple(-1),//14
                     new HTuple(-1)//15
                });

            fileCamera.strName = path;
            listCamera.Add(fileCamera);
        }
    }
}
