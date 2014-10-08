using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            const int chunkSize = 2 * 1024; // 2KB
            var path = @"E:\Projetos\InfoTech2u - Copia\Verithus\Codificação\Banco de Dados\Procedures";


            var inputFiles = Directory.GetFiles(path);


            var output = @"E:\Projetos\InfoTech2u - Copia\Verithus\Codificação\Banco de Dados\Procedures\ProceduresCreation.sql";

            foreach (var file in inputFiles)
            {
                var input = File.ReadAllText(file);
                File.AppendAllText(output, "GO" + Environment.NewLine);
                File.AppendAllText(output, input + Environment.NewLine);
            }
            
        }
    }
}
