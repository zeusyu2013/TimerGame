using System.Collections.Generic;

public class AirPortData
{
    private static int[,] AirPlanes = new int[Define.AirportPlaneCount, Define.AirportPlaneCount];
    private static int[] AirPlaneStates = new int[Define.AirportPlaneCount * Define.AirportPlaneCount];

    public static int[,] GetAirPlanes()
    {
        return AirPlanes;
    }

    public static List<int> GetAirPlanesList()
    {
        List<int> list = new List<int>();

        for (int i = 0; i < Define.AirportPlaneCount; ++i)
        {
            for (int j = 0; j < Define.AirportPlaneCount; ++j)
            {
                list.Add(AirPlanes[i, j]);
            }
        }

        return list;
    }

    public static bool AddAirPlane(int id, int row = -1, int col = -1)
    {
        if (!CheckInvaild(row) && !CheckInvaild(col))
        {
            if (AirPlanes[row, col] != 0)
            {
                return false;
            }

            AirPlanes[row, col] = id;

            return true;
        }

        for (int i = 0; i < Define.AirportPlaneCount; ++i)
        {
            for (int j = 0; j < Define.AirportPlaneCount; ++j)
            {
                if (AirPlanes[i, j] == 0)
                {
                    AirPlanes[i, j] = id;
                    return true;
                }
            }
        }

        UpdateFlights();

        return false;
    }

    public static bool RemoveAirPlane(int row, int col)
    {
        if (CheckInvaild(row) ||
            CheckInvaild(col))
        {
            return false;
        }

        AirPlanes[row, col] = 0;

        UpdateFlights();

        return true;
    }

    public static bool MergeAirPlane(int srcRow, int srcCol, int destRow, int destCol)
    {
        if (CheckInvaild(srcRow) ||
            CheckInvaild(srcCol) ||
            CheckInvaild(destRow) ||
            CheckInvaild(destCol))
        {
            return false;
        }

        // 任一格子为空
        if (AirPlanes[srcRow, srcCol] == 0 ||
            AirPlanes[destRow, destCol] == 0)
        {
            return false;
        }

        // 不是同一类飞机
        if (AirPlanes[srcRow, srcCol] != AirPlanes[destRow, destCol])
        {
            return false;
        }

        int id = AirPlanes[srcRow, srcCol];
        RemoveAirPlane(srcRow, srcCol);
        RemoveAirPlane(destRow, destCol);
        AddAirPlane(id + 1, destRow, destCol);

        UpdateFlights();

        return true;
    }

    private static bool CheckInvaild(int i)
    {
        if (i < 0 || i > Define.AirportPlaneCount)
        {
            return true;
        }
        return false;
    }

    public static void UpdateFlights()
    {
        string flights = "";
        for (int i = 0; i < Define.AirportPlaneCount; ++i)
        {
            for (int j = 0; j < Define.AirportPlaneCount; ++j)
            {
                if (i == 0 && j == 0)
                {
                    flights = Utils.StringBuilder(flights, AirPlanes[i, j]);
                }
                else
                {
                    flights = Utils.StringBuilder(flights, ",", AirPlanes[i, j]);
                }
            }
        }

        OwnerData.Instance.Flights = flights;
    }

    public static void ParseFlights()
    {
        string flights = OwnerData.Instance.Flights;
        if (string.IsNullOrEmpty(flights))
        {
            return;
        }

        string[] array = flights.Split(',');
        if (array == null || array.Length < 1)
        {
            return;
        }

        for (int i = 0; i < Define.AirportPlaneCount; ++i)
        {
            for (int j = 0; j < Define.AirportPlaneCount; ++j)
            {
                AirPlanes[i, j] = Utils.String2Int(array[i * 5 + j]);
            }
        }
    }
}
