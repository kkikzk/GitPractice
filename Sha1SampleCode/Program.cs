using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sha1SampleCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sep = Path.DirectorySeparatorChar;
            var path = "." + sep + ".." + sep + ".." + sep + ".." + sep + ".." + sep + "hello.txt";
            using (var br = File.OpenRead(new DirectoryInfo(".").FullName + path))
            {
                // ハッシュアルゴリズム生成
                var algorithm = new SHA1CryptoServiceProvider();

                // ハッシュ値を計算する
                var bs = algorithm.ComputeHash(br);

                // リソースを解放する
                algorithm.Clear();

                // バイト型配列を16進数文字列に変換
                var result = new StringBuilder();
                foreach (var b in bs)
                {
                    result.Append(b.ToString("X2"));
                }

                Console.WriteLine(result.ToString());
            }
        }
    }
}