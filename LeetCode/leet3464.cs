public class Solution {
    public int MaxDistance(int squareSide, int[][] boundaryPoints, int requiredPoints) {
        List<long> perimeterPositions = new List<long>();

        // Convert 2D boundary points into 1D positions along the square perimeter
        foreach (var point in boundaryPoints) {
            int x = point[0], y = point[1];

            if (x == 0) {
                // Left edge (bottom to top)
                perimeterPositions.Add(y);
            } 
            else if (y == squareSide) {
                // Top edge (left to right)
                perimeterPositions.Add(squareSide + (long)x);
            } 
            else if (x == squareSide) {
                // Right edge (top to bottom)
                perimeterPositions.Add(3L * squareSide - y);
            } 
            else {
                // Bottom edge (right to left)
                perimeterPositions.Add(4L * squareSide - x);
            }
        }

        perimeterPositions.Sort();

        long minDistance = 1, maxDistance = squareSide;
        int bestDistance = 0;

        // Binary search for the maximum valid minimum distance
        while (minDistance <= maxDistance) {
            long candidateDistance = (minDistance + maxDistance) / 2;

            if (CanPlacePoints(perimeterPositions, squareSide, requiredPoints, candidateDistance)) {
                bestDistance = (int)candidateDistance;
                minDistance = candidateDistance + 1;
            } else {
                maxDistance = candidateDistance - 1;
            }
        }

        return bestDistance;
    }

    private bool CanPlacePoints(List<long> positions, int sideLength, int pointsToSelect, long minSpacing) {
        long totalPerimeter = 4L * sideLength;

        foreach (long startPosition in positions) {
            long maxAllowedPosition = startPosition + totalPerimeter - minSpacing;
            long currentPosition = startPosition;

            // Try to greedily place remaining points
            for (int count = 0; count < pointsToSelect - 1; count++) {
                int nextIndex = FindFirstAtLeast(positions, currentPosition + minSpacing);

                if (nextIndex == positions.Count || positions[nextIndex] > maxAllowedPosition) {
                    currentPosition = -1;
                    break;
                }

                currentPosition = positions[nextIndex];
            }

            if (currentPosition >= 0) {
                return true;
            }
        }

        return false;
    }

    private int FindFirstAtLeast(List<long> sortedList, long targetValue) {
        int left = 0, right = sortedList.Count;

        while (left < right) {
            int mid = left + (right - left) / 2;

            if (sortedList[mid] < targetValue) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }

        return left;
    }
}