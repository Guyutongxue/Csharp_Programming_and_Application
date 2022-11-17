# 作业 5

## 原生字符串字面量

```csharp
string longMessage = """
    This is a long message.
    It has several lines.
        Some are indented
                more than others.
    Some should start at the first column.
    Some have "quoted text" in them.
    """;
```

开头、结尾的 `"` 可为任意数量（类比 Rust 中的 '#' 和 C++ 中的 `R...()...`）。

旧写法

```csharp
string longMessage = @"
    This is a long message.
    It has several lines.
        Some are indented
                more than others.
    Some should start at the first column.
    Some have ""quoted text"" in them.
    ";
```


## UTF-8 字符串字面量

```csharp
byte[] someString = "我❤️中国"u8.ToArray();
```

旧写法

```csharp
byte[] someString = Encoding.UTF8.GetBytes("我❤️中国");
```

## 解构赋值+初始化

```csharp
int x;

(x, int y) = point;
```

旧写法

```csharp
int x;

int y;
(x, y) = point;
```

## 顶级语句

```csharp
Console.WriteLine("Hello, world!");
```

整个文件就一句话。

旧写法

```csharp
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
        }
    }
}
```

## 可空引用类型标注

```csharp
string? nullable = null;
string notNull = null; // WARNING

nullable.Length; // WARNING
nullable?.Length; // result in int?
```

旧写法：无

## 范围运算符

```csharp
int[] numbers = new[] { 0, 10, 20, 30, 40, 50 };
int[] subset = numbers[1..4];
```

旧写法

```csharp
int[] subset = numbers.Skip(1).Take(3).ToArray();
```

## 可空值类型

```csharp
int? maybe = 12;
if (maybe is int number) {
    Console.WriteLine($"{number}");
}
```

旧写法：无

## 模式匹配

```csharp
string grade = score switch
    {
        100 => "A+",
        (>= 90) and (< 100) => "A",
        (>= 75) and (< 90) => "B",
        (>= 60) and (< 75) => "C",
        _ => "F"
    };
```

旧写法

```csharp
string grade;
if (score == 100) grade = "A+";
else if (score >= 90 && score < 100) grade = "A";
else if (score >= 75 && score < 90) grade = "B";
else if (score >= 60 && score < 75) grade = "C";
else grade = "F";
```

## 局部函数

```csharp
private void f() {
    int x = 0;
    void g() {
        x++;
    }
    g();
    g();
}
```

旧写法：无

## 格式字符串

```csharp
var name = "world";
string s = $"Hello, {name}!";
```

旧写法：

```csharp
var name = "world";
string s = "Hello, " + name.ToString() + "!";
```
