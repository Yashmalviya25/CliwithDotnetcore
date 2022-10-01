using CommandLineTool.Attributes;
using System.Diagnostics;
namespace microsoft.cli
{
    [App("my application")]
    public class MyCli
    {
        /// <summary>
        /// Private static method Example
        /// </summary>
        /// <param name="v">simple string</param>
        [Command("privateprint", "Private static command")]
        private static void PrivatePrint(
            [ParamArgument()] object v) => Console.WriteLine($"type: {v.GetType()}, {v}");

        /// <summary>
        /// public method sample
        /// </summary>
        /// <param name="v"></param>
        [Command("publicprint", "public method command")]
        public void PublicPrint(
            [ParamArgument()] object v)
            => Console.WriteLine($"type: {v.GetType()}, {v}");

        /// <summary>
        /// List of string as Arguments
        /// Ex: lst val1 val2 -> List<string>{val1,val2}
        /// </summary>
        /// <param name="lst"></param>
        [Command("listprint", "mapping arguments with list")]
        public void Listprint(
            [ParamArgument()] List<object> lst)
            => lst.ForEach(v => Console.WriteLine($"type: {v.GetType()}, {v}"));

        /// <summary>
        /// get custom object list
        /// Ex: files <file1_path> <file2_path> -> List<FileInfo>{file1_path,file2_path}
        /// </summary>
        /// <param name="lst"></param>
        [Command("files", "mapping arguments with complex type arguments")]
        public void MethodFiles(
            [ParamArgument()] List<FileInfo> lst)
            => lst.ForEach(v => Console.WriteLine($"type: {v.GetType()}, {v.FullName}"));

        /// <summary>
        /// option sample
        /// Ex: files <file1_path> <file2_path> -> List<FileInfo>{file1_path,file2_path}
        /// </summary>
        /// <param name="lst"></param>
        [Command("options", "using options")]
        public void MethodOptions(
            [ParamArgument()] object v, [ParamOption("-a")] object op1)
        {
            Console.WriteLine($"type: {v.GetType()}, {v}");
            Console.WriteLine($"type: {op1.GetType()}, {op1}");
        }

        [Command("gitdownload", "cloning files from git")]
        public void GitDownload(
            [ParamArgument()] string v)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "cmd.exe";
            ps.WindowStyle = ProcessWindowStyle.Normal;
            ps.Arguments = @"/k git clone "+ v;
            Process.Start(ps);
            Console.WriteLine($"type: {v.GetType()}, {v}");
            
        }
    }
}