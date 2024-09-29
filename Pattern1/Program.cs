using System;

class C1
{
    private const int a = 5;
    public const int b = 10;
    protected const int c = 15;

    private bool privateBoolean;
    public bool publicBoolean;
    protected bool protectedBoolean;

    private string PrivateProperty { get; set; }
    public string PublicProperty { get; set; }
    protected string ProtectedProperty { get; set; }

    public C1()
    {
        privateBoolean = false;
        publicBoolean = true;
        PublicProperty = "Default public property";
        Console.WriteLine("Конструктор по умолчанию");
    }

    public C1(bool privateBoolean)
    {
        this.privateBoolean = privateBoolean;
        publicBoolean = false;
        PublicProperty = "Public property with privateBoolean";
        Console.WriteLine("Конструктор с параметром");
    }

    public C1(C1 program)
    {
        privateBoolean = program.privateBoolean;
        publicBoolean = program.publicBoolean;
        PublicProperty = program.PublicProperty;
        Console.WriteLine("Конструктор копирования");
    }

    private void PrivateMethod()
    {
        Console.WriteLine("Private method");
    }

    public void PublicMethod()
    {
        Console.WriteLine("Public method");
    }

    protected void ProtectedMethod()
    {
        Console.WriteLine("Protected method");
    }
}

interface I1
{
    int MyProperty { get; set; }

    void MyMethod();

    event EventHandler MyEvent;

    int this[int index] { get; set; }
}

class C2 : I1
{
    public int MyProperty { get; set; }

    public event EventHandler MyEvent;

    private int[] array = new int[10];
    public int this[int index]
    {
        get { return array[index]; }
        set { array[index] = value; }
    }

    private bool privateBoolean;
    public bool publicBoolean;
    protected bool protectedBoolean;

    private string PrivateProperty { get; set; }
    public string PublicProperty { get; set; }
    protected string ProtectedProperty { get; set; }

    public C2()
    {
        privateBoolean = false;
        publicBoolean = true;
        PublicProperty = "Default public property";
        Console.WriteLine("Конструктор по умолчанию C2");
    }
    public C2(bool privateBoolean)
    {
        this.privateBoolean = privateBoolean;
        publicBoolean = false;
        PublicProperty = "Public property with privateBoolean";
        Console.WriteLine("Конструктор с параметром C2");
    }

    public C2(C2 program)
    {
        privateBoolean = program.privateBoolean;
        publicBoolean = program.publicBoolean;
        PublicProperty = program.PublicProperty;
        Console.WriteLine("Конструктор копирования C2");
    }
    public void MyMethod()
    {
        Console.WriteLine("Реализация MyMethod из интерфейса I1 в классе C2");
    }

    private void PrivateMethod()
    {
        Console.WriteLine("Private method C2");
    }

    public void PublicMethod()
    {
        Console.WriteLine("Public method C2");
    }

    protected void ProtectedMethod()
    {
        Console.WriteLine("Protected method C2");
    }

}

class C3
{
    public string PublicField = "Public Field";
    protected string ProtectedField = "Protected Field";
    private int PrivateField = 100;

    public string PublicProperty { get; set; } = "Public Property";
    protected string ProtectedProperty { get; set; } = "Protected Property";
    private int PrivateProperty { get; set; } = 123;

    public C3()
    {
        Console.WriteLine("Конструктор C3");
    }

    public void PublicMethod()
    {
        Console.WriteLine("PublicMethod C3");
    }

    protected void ProtectedMethod()
    {
        Console.WriteLine("ProtectedMethod C3");
    }

    private void PrivateMethod()
    {
        Console.WriteLine("PrivateMethod C3");
    }
}

class C4 : C3
{
    public C4()
    {
        Console.WriteLine("Конструктор C4");
    }
    public void SetProtectedField(string value)
    {
        ProtectedField = value;
        Console.WriteLine($"ProtectedField изменен на: {ProtectedField}");
        ProtectedMethod();
    }

    public new void PublicMethod()
    {
        Console.WriteLine("PublicMethod C4");
        base.PublicMethod();
    }

}


class Program
{
    static void Main(string[] args)
    {

        C1 c1 = new C1();
        c1.PublicMethod();  
        Console.WriteLine($"Public Property: {c1.PublicProperty}"); 

        C1 c2 = new C1(true);
        c2.PublicMethod();
        Console.WriteLine($"Public Property: {c2.PublicProperty}");


        C1 c3 = new C1(c2);
        c3.PublicMethod();
        Console.WriteLine($"Public Property (copied): {c3.PublicProperty}");

        c1.publicBoolean = false;
        Console.WriteLine($"Public Boolean: {c1.publicBoolean}");

        Console.WriteLine("================");

        C2 obj1 = new C2();
        obj1.PublicMethod(); 
        obj1.PublicProperty = "New value for PublicProperty";  
        Console.WriteLine($"PublicProperty: {obj1.PublicProperty}");

        obj1[0] = 100;
        Console.WriteLine($"obj1[0]: {obj1[0]}");

        obj1.MyProperty = 42;
        Console.WriteLine($"MyProperty (from I1): {obj1.MyProperty}");
        obj1.MyMethod(); 

        C2 obj2 = new C2(true);
        obj2.PublicMethod(); 
        Console.WriteLine($"PublicProperty: {obj2.PublicProperty}");


        C2 obj3 = new C2(obj1);
        obj3.PublicMethod(); 
        Console.WriteLine($"PublicProperty (скопированное значение): {obj3.PublicProperty}");

        Console.WriteLine("===================");

        C4 obj4 = new C4();

        Console.WriteLine($"PublicField (унаследованное поле): {obj4.PublicField}");  
        obj4.PublicMethod();  

        obj4.PublicProperty = "New value";
        Console.WriteLine($"PublicProperty (унаследованное свойство): {obj4.PublicProperty}");


        obj4.SetProtectedField("New value for ProtectedField");

        obj4.PublicMethod();

    }
}
