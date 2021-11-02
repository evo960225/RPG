using System.IO;


namespace hoshi_lib {
    static public class Log {
        static private StreamWriter SW = new StreamWriter("Log.txt");

        static public void Write(string msg) {
            var time = System.DateTime.UtcNow;
            SW.WriteLine("["+ time.ToLongTimeString() +"]: " + msg);
            SW.Flush();
        }
    }
}
