public class FileStreamExample  
{  
    public static void Main(string[] args)  
    {  
        FileStream f = new FileStream("~\Users\asusl\OneDrive\Documents\b.txt", FileMode.OpenOrCreate);//creating file stream  
        f.WriteByte(65);//writing byte into stream  
        f.Close();//closing stream  
    }  
}