using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = { ' ','\t' };
            

            string wit = Console.ReadLine();//書かれた文字

            Console.WriteLine("x-component of the translation :");
            string xtr = Console.ReadLine();//書かれた文字
            Console.WriteLine("y - component of the translation:");
            string ytr = Console.ReadLine();//書かれた文字
            Console.WriteLine("z-component of the translation :");
            string ztr = Console.ReadLine();//書かれた文字

            

            string filenameWOExt;//拡張子を消したもの
            filenameWOExt = Path.GetFileNameWithoutExtension(wit);//拡張子を取り除く
           // Console.WriteLine(filenameWOExt + "_transformed.mqo");

            
            StreamReader sr = new StreamReader(wit);//ファイル読み込み
            StreamWriter sw = new StreamWriter(filenameWOExt + "_transformed.mqo");//ファイル作成
            string str;
            int v=0;//文字8をint型に変換
            bool t = true;//書き出すか否かの真偽
            int s = 0;//頂点の数だけ文章を表示するための変数
            string[] data;//1文の単語を1つずつ格納
            string[] Svertex;//文字の頂点情報
            double[] vertex = new double[3];//double型の頂点情報

            //書かれた文字を数値に変換
            double x = double.Parse(xtr);
            double y = double.Parse(ytr);
            double z = double.Parse(ztr);



            while ((str = sr.ReadLine()) != null)//ファイル書き出し
            {
                data = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
          
                //頂点の数だけ文章を表示する
                if (s > 0)　　　//0になったら終了
                {                   
                    Svertex = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    for (int j=0; j<3; j++) {
                        vertex[j] = double.Parse(Svertex[j]);
                    }
                    //元の頂点に書かれた分を足す
                    vertex[0] += x;
                    vertex[1] += y;
                    vertex[2] += z;

                    Console.WriteLine("\t\t" + vertex[0] +" " + vertex[1] + " " + vertex[2]);
                    sw.WriteLine("\t\t" + vertex[0] + " " + vertex[1] + " " + vertex[2]);//ファイルに書き出し

                    t = false;
                    s--;            
                }

                if (Array.Exists<String>(data, (m) => { return (m.CompareTo("vertex") == 0); }) == true) {

                    //Console.WriteLine("vertex = " + data[1]);//コンソールに書き出し
                    v = int.Parse(data[1]);//数に変換
                    s = v;
                }

                if (t == true) {
                    Console.WriteLine(str);//コンソールに書き出し
                    sw.WriteLine(str);//ファイルに書き出し
                }
                t = true;//元に戻す



                }
            sr.Close();                      
            sw.Close();

            Console.ReadKey();
            
        }
    }
}
