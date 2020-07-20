using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Vision
{
    /// <summary>
    /// 系统数据存储类
    /// </summary>
    public class SystemData
    {


        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="path">存储路径</param>
        /// <param name="data">序列化对象</param>
        public static void Write(string path, object data)
        {
            using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))//文件写入流
            {
                BinaryFormatter bf = new BinaryFormatter();//创建序列化器
                bf.Serialize(fsWrite, data);//序列化

            }
        }


        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static object Read(string path)
        {
            using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))//文件读取流
            {
                BinaryFormatter bf = new BinaryFormatter();//创建序列化器
                return bf.Deserialize(fsRead);//反序列化
            }
        }
    }
}
