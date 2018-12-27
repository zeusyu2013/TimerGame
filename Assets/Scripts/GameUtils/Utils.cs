using System.Text;
using LitJson;

public class Utils
{
    private static StringBuilder sb = new StringBuilder();
    public static string StringBuilder(params object[] args)
    {
        sb.Remove(0, sb.Length);
        foreach (object o in args)
        {
            sb.Append(o);
        }

        return sb.ToString();
    }

    #region <>类型转换<>

    public static int String2Int(string str)
    {
        int value = 0;
        if (string.IsNullOrEmpty(str))
        {
            return value;
        }

        int.TryParse(str, out value);
        return value;
    }

    public static float String2Float(string str)
    {
        float value = 0.0f;
        if (string.IsNullOrEmpty(str))
        {
            return value;
        }

        float.TryParse(str, out value);
        return value;
    }

    #endregion

    public static int GetJsonInt(JsonData data)
    {
        if (data == null)
        {
            return 0;
        }

        return String2Int(data.ToString());
    }

    public static float GetJsonFloat(JsonData data)
    {
        if (data == null)
        {
            return 0.0f;
        }

        return String2Float(data.ToString());
    }
}
