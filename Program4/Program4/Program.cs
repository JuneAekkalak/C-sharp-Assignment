using System;

class Box
{
    private double width;
    private double height;
    private double length;

    public Box(double width, double height, double length)
    {
        this.width = width;
        this.height = height;
        this.length = length;
    }

    public Box(double side)
    {
        this.width = side;
        this.height = side;
        this.length = side;
    }

    public Box(Box oldBox)
    {
        this.width = oldBox.width;
        this.height = oldBox.height;
        this.length = oldBox.length;
    }

    public double FaceArea()
    {
        return this.width * this.height;
    }

    public double TopArea()
    {
        return this.width * this.length;
    }

    public double SideArea()
    {
        return this.height * this.length;
    }

    public double Area()
    {
        return 2 * FaceArea() + 2 * TopArea() + 2 * SideArea();
    }

    public static void Main()
    {
        Box? customBox = null;
        int choice;

        do
        {
            Console.WriteLine("Choose a box type:");
            Console.WriteLine("1. Custom Box");
            Console.WriteLine("2. Cube");
            Console.WriteLine("3. Copy Box");
            Console.WriteLine("4. Exit");

            Console.Write("Select choice : ");
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    customBox = CreateCustomBox();
                    if (customBox != null)
                    {
                        Console.WriteLine("Area of custom box: " + customBox.Area());
                    }
                    break;
                case 2:
                    CreateAndDisplayCube();
                    break;
                case 3:
                    if (customBox != null)
                    {
                        Box? copyBox = CopyBox(customBox);
                        Console.WriteLine("Area of copy box: " + copyBox.Area());
                    }
                    else
                    {
                        Console.WriteLine("No custom box has been created yet.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 4);
    }

    private static Box CreateCustomBox()
    {
        double width;
        double height;
        double length;

        Console.Write("Enter width: ");
        double.TryParse(Console.ReadLine(), out width);

        Console.Write("Enter height: ");
        double.TryParse(Console.ReadLine(), out height);

        Console.Write("Enter length: ");
        double.TryParse(Console.ReadLine(), out length);

        return new Box(width, height, length);
        
    }

    private static void CreateAndDisplayCube()
    {
        double side;

        Console.Write("Enter the side length for the cube: ");
        double.TryParse(Console.ReadLine(), out side);

        Box cube = new Box(side);
        Console.WriteLine("Area of cube: " + cube.Area());
    }

    private static Box CopyBox(Box? customBox)
    {
        if (customBox != null)
        {
            return new Box(customBox);
        }
        else
        {
            throw new InvalidOperationException("No custom box has been created yet.");
        }
    }

}
