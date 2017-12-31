using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerSkyLite_CS.Controller
{
    static public class FileController
    {
        
        /// <summary>
        /// 安全的合并路径
        /// </summary>
        /// <param name="DirectoryPath"></param>
        /// <param name="FileName"></param>
        /// <returns></returns>
        static public string PathCombine(string DirectoryPath, string FileName)
        {
            UnityModule.DebugPrint("合并文件路径：\"{0}\" + \"{1}\"",DirectoryPath,FileName);
            if (!DirectoryPath.EndsWith("\\")) DirectoryPath += "\\";
            return (DirectoryPath + FileName).Replace("\\\\", "\\");
        }

        ///<summary>
        /// 保存资源文件里的文件到硬盘
        /// </summary>
        /// <param name = "ResourceByte" > 资源文件的指定资源 </ param >
        /// < param name="FilePath">储存路径</param>
        /// <return>检测文件是否释放成功</return>
        public static bool SaveResource(byte[] ResourceByte, string FilePath)
        {
            //TODO:需要测试
            using (FileStream ResourceStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                if (ResourceStream.CanWrite)
                {
                    try
                    {
                        ResourceStream.Write(ResourceByte, 0, ResourceByte.Length);
                    }
                    catch (Exception ex)
                    {
                        ResourceStream.Dispose();
                        throw ex;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

    }
}
