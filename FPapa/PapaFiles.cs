﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SsWpfApp5
{
    /// <summary>
    /// Actions with files
    /// </summary>
    partial class Papa
    {

        
        public static void MyDelete(string fName)
        {
            #region
            try
            {
                File.Delete(fName);
                SayDarkGray(" Удалён " + fName);
            }
            catch { Sos("Ошибка удаления", fName); }
            #endregion
        }

        
        public static void MoveOneFile(string oldName, string newName)
        {
            #region
            FileInfo fileInfo = new FileInfo(newName);
            if (fileInfo.Exists) MyDelete(newName);
            try
            {
                File.Move(oldName, newName);
                info += $"{newName}\n";
            }
            catch { Alarm("Ошибка перемещения", newName); }
            #endregion
        }


        public static void CopyOneFile(string oldName, string newName)
        {
            #region
            FileInfo fileInfo = new FileInfo(newName);
            if (fileInfo.Exists) MyDelete(newName);
            try
            {
                File.Copy(oldName, newName, true);
                SayBlue(" Скопирован " + newName);
            }
            catch { Alarm("Ошибка копирования", newName); }
            #endregion
        }


        public static void Coper(string dirInCopy, string dirOutCopy)
        {
            #region #Coper
            DirectoryInfo d = new DirectoryInfo(dirInCopy);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string oldName = f.FullName;
                string newName = Path.Combine(dirOutCopy, f.Name);
                CopyOneFile(oldName, newName);
            }
            #endregion
        }

        public static void CoperDate(string dirInCopy, string dirOutCopy)
        {
            #region #CoperDate
            var now = DateNowDots();
            DirectoryInfo d = new DirectoryInfo(dirInCopy);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string oldName = f.FullName;
                string newName = Path.Combine(dirOutCopy, now + "_" + f.Name);
                if (f.Name.IndexOf("terminals") > -1 || f.Name.IndexOf("departments") > -1)
                    CopyOneFile(oldName, newName);
            }
            #endregion
        }

        public static void CoperRp(string dirInCopy, string dirOutCopy)
        {
            #region #Coper
            DirectoryInfo d = new DirectoryInfo(dirInCopy);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                if (f.FullName.IndexOf("RP") > -1)
                {
                    string oldName = f.FullName;
                    string newName = Path.Combine(dirOutCopy, f.Name);
                    CopyOneFile(oldName, newName);
                }
            }
            #endregion
        }


        public static void Mover(string dirInMove, string dirOutMove)
        {
            #region #Mover
            DirectoryInfo d = new DirectoryInfo(dirInMove);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string oldName = f.FullName;
                string newName = Path.Combine(dirOutMove, f.Name);
                MoveOneFile(oldName, newName);
            }
            #endregion
        }


        public static void Clon(string dirInClone, string dirOutClone)
        {
            #region #Clon
            DirectoryInfo d = new DirectoryInfo(dirInClone);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string oldName = f.FullName;
                string newName = Path.Combine(dirOutClone, f.Name);
                CopyOneFile(oldName, newName);

            }
            #endregion
        }

        /// <summary>
        /// Copy files in directory
        /// </summary>
        /// <param name="dirInClone"></param>
        /// <param name="dirOutClone"></param>
        public static void ClonAccess(string dirInClone, string dirOutClone)
        {
            #region
            DirectoryInfo d = new DirectoryInfo(dirInClone);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string oldName = f.FullName;
                string newName = Path.Combine(dirOutClone, f.Name);
                CopyOneFile(oldName, newName);
            }
            #endregion
        }

        /// <summary>
        /// Delete all files in folder
        /// </summary>
        /// <param name="path"></param>
        public static void ClearFolder(string path)
        {
            #region #ClearFolder
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string delName = f.FullName;
                MyDelete(delName);
            }
            #endregion
        }

        public static void ClearFolderPdf(string path)
        {
            #region #ClearFolder
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                string delName = f.FullName;
                if (delName.IndexOf(".pdf") > -1 || delName.IndexOf(".PDF") > -1) MyDelete(delName);
            }
            #endregion
        }


        internal static List<string> GetFilesFromFolder(string path)
        {
            #region #ClearFolder
            var rez = new List<string>();
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo[] infos = d.GetFiles("*.*");
            foreach (FileInfo f in infos)
            {
                try
                {
                    string fName = f.FullName.ToString();
                    rez.Add(fName);
                }
                catch { Alarm("Ошибка GetFilesFromFolder", path); }
            }
            return rez;
            #endregion
        }

    }
}
