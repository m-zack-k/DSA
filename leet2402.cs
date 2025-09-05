using System;
using System.Collections.Generic;

public class Solution {
    public int MostBooked(int n, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
        SortedSet<int> idleRooms = new SortedSet<int>();
        for (int i = 0; i < n; i++)
        {
            idleRooms.Add(i);
        }

        SortedSet<(long, int)> busyRooms = new SortedSet<(long, int)>(
         Comparer<(long, int)>.Create((a, b) =>
             a.Item1 != b.Item1 ? a.Item1.CompareTo(b.Item1) : a.Item2.CompareTo(b.Item2)
         )
         );

        int[] count = new int[n];

        foreach (var meeting in meetings)
        {
            int start = meeting[0];
            int end = meeting[1];

            while (busyRooms.Count > 0 && busyRooms.Min.Item1 <= start)
            {
                var room = busyRooms.Min;
                busyRooms.Remove(room);
                idleRooms.Add(room.Item2);
            }

            int roomId;
            if (idleRooms.Count > 0)
            {
                // Use the smallest room ID available
                roomId = idleRooms.Min;
                idleRooms.Remove(roomId);
                busyRooms.Add((end, roomId));
            }
            else
            {
                // Wait for the earliest room to become free
                var earliest = busyRooms.Min;
                busyRooms.Remove(earliest);
                roomId = earliest.Item2;
                long newEnd = earliest.Item1+ (end - start);
                busyRooms.Add((newEnd, roomId));
            }

            count[roomId]++;
        }
        
        int mostBookedRoom = 0;
        for (int i = 1; i < n; i++)
        {
            if (count[i] > count[mostBookedRoom])
                mostBookedRoom = i;
        }

        return mostBookedRoom;

    }
}