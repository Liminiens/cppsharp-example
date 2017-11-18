class HelloClass {
public:
    void hello();
};

class Foo
{
public:
    int a;
    float b;
    void print();
    Foo(int a, float b);
};

int FooAdd(Foo* foo);
