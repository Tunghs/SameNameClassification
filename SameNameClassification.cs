using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sameNameClassification
{
    class Program
    {
        private void CreateSubDir(int num, string savePath)
        {
            for (int i = 0; i < num; i++)
            {
                int j = i + 1;
                string newDirPath = savePath + @"\파일" + j;

                DirectoryInfo subDir = new DirectoryInfo(newDirPath);
                if(subDir.Exists == false)
                {
                    subDir.Create();
                }
            }
        }

        private void MoveFile(string path)
        {

        }

        private int GetDirFileNum(string path)
        {
            int fileNum = 0;

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            foreach (System.IO.FileInfo file in dir.GetFiles())
            {
                if (file.Name == "Thumbs.db")
                {
                    continue;
                }
                fileNum++;
            }
            return fileNum;
        }

        /// <summary>
        /// Return subdirectory names as a list
        /// </summary>
        /// <param name="path">path</param>
        /// <returns></returns>
        private List<string> GetSubDirList(string path)
        {
            List<string> subDirList = new List<string>();

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(path);
            foreach (System.IO.DirectoryInfo subDir in dir.GetDirectories())
            {
                subDirList.Add(subDir.FullName);
            }

            return subDirList;
        }

        private bool CheckSubDirFileNum(List<string> list)
        {
            int[] subFileNumArr = new int[list.Count];
            int i = 0;
            bool check = true;

            foreach (string subDir in list)
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(subDir);

                subFileNumArr[i] = GetDirFileNum(subDir);
                i++;
            }

            for (int j = 0; j < subFileNumArr.Length-1; j++)
            {
                if (subFileNumArr[j] != subFileNumArr[j + 1])
                {
                    check = false;
                }
            }

            if (check)
            {
                return check;
            }
            else
            {
                return check;
            }
            
        }
        /// <summary>
        /// Returns the number of directories to create
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private int GetCreateFileNum(string path)
        {
            string subDirPath = "";

            foreach (string subDir in GetSubDirList(path))
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(subDir);
                subDirPath = dir.FullName;
                break;
            }

            return GetDirFileNum(subDirPath);
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            string savePath = @"C:\Users\sualab\Desktop\mv 팀\정렬";
            string dirPath = @"C:\Users\sualab\Desktop\mv 팀\00_RawData";

            // Available in the same number of subdirectories and in the same order.
            if (p.CheckSubDirFileNum(p.GetSubDirList(dirPath)))
            {

                p.CreateSubDir(p.GetCreateFileNum(dirPath), savePath);

            }
            else
            {
                Console.WriteLine("디렉토리의 파일 개수가 다릅니다.");
            }    
        }
    }
}
