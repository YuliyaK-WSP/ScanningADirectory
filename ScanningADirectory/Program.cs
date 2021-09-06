using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanningADirectory
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream HTML = new FileStream("programma.html", FileMode.Create); //создаем файловый поток
            StreamWriter HTMLwriter = new StreamWriter(HTML, Encoding.GetEncoding("windows-1251"));// соединяем файловый поток с "Потоковым писателем"
            Console.WriteLine("Введите директорию");
            string dirName = Console.ReadLine();


            HTMLwriter.WriteLine("<!DOCTYPE HTML>");
            HTMLwriter.WriteLine("<html><head>");
            HTMLwriter.WriteLine("<title>Скан</title>");
            HTMLwriter.WriteLine("<META content=\"text/html; charset=windows-1251\" http-equiv=\"Content-Type\">");
            HTMLwriter.WriteLine("<style> .nested {font-weight: bold; font-style: italic;color:blue} </style>");
            HTMLwriter.WriteLine("<style> .caret {cursor: pointer;-webkit - user - select: none; /* Safari 3.1+ */-moz - user - select: none; /* Firefox 2+ */-ms - user - select: none; /* IE 10+ */user - select: none;}</style>");
            HTMLwriter.WriteLine("<style> .caret::befor{content: 25B6;color: black;display: inline - block;margin - right: 6px;}</style>");
            HTMLwriter.WriteLine("<style> .nested {display:none ;}</style>");
            HTMLwriter.WriteLine("</head>");
            HTMLwriter.WriteLine("<body>");
            HTMLwriter.WriteLine("<div>");
            
            ScanningADirectory(dirName,HTMLwriter);
            HTMLwriter.WriteLine("</div>");
            HTMLwriter.WriteLine("</body>");
            HTMLwriter.WriteLine("</html>");
            HTMLwriter.Close();

        }
        public static void ScanningADirectory(string dirName,StreamWriter HTMLwriter)
        {
            if (Directory.Exists(dirName))
            {
                HTMLwriter.WriteLine($"<li class = \"caret\">{dirName}</li>");
                

                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {

                    string[] files = Directory.GetFiles(dirName);
                   
                    foreach (string f in files)
                    {
                        FileInfo file = new FileInfo(f);
                        HTMLwriter.WriteLine($"<li class = \"nested\">{files}</li>");
                        HTMLwriter.WriteLine(f + " " + file.Length + " байт");
                        HTMLwriter.WriteLine("<br>");
                       
                    }
                    ScanningADirectory(s,HTMLwriter);
                    HTMLwriter.WriteLine("<br>");

                }
                //Console.WriteLine();
               
                
            }
        }
    }
   
}
