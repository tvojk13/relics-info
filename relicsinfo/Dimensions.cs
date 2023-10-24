using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relicsInfo
{
	public struct TessRectangle
	{
		public int x;
		public int y;
		public int width;
		public int height;
		public static List<TessRectangle> rectangles = new List<TessRectangle>();

		public TessRectangle(int xPos, int yPos, int rectWidth, int rectHeight)
		{
			this.x = xPos;
			this.y = yPos;
			this.width = rectWidth;
			this.height = rectHeight;
		}


		public static List<TessRectangle> getRectangles(int rewardsCount)
		{
			switch (rewardsCount)
			{
				case 2:
				{
					TessRectangle rectangle = new TessRectangle(705, 220, 250, 242);
					for (int i = 0; i < 2; i++)
					{
						rectangles.Add(rectangle);
						rectangle.x += rectangle.width + 5;
						rectangle = new TessRectangle(rectangle.x, 220, 250, 242);
					}

					return rectangles;
				}
				case 3:
				{
					TessRectangle rectangle = new TessRectangle(585, 220, 250, 242);
					for (int i = 0; i < 3; i++)
					{
						rectangles.Add(rectangle);
						rectangle.x += rectangle.width + 5;
						rectangle = new TessRectangle(rectangle.x, 220, 250, 242);
					}

					return rectangles;
				}
				case 4:
				{
					TessRectangle rectangle = new TessRectangle(460, 220, 250, 242);
					for (int i = 0; i < 4; i++)
					{
						rectangles.Add(rectangle);
						rectangle.x += rectangle.width + 5;
						rectangle = new TessRectangle(rectangle.x, 220, 250, 242);
					}

					return rectangles;
				}
			}

			return null;
		}
	}
}
