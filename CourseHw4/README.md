# 作业 4

## `System.Object`

1. `public virtual`。
2. 第一个 `Equals` 是虚方法，可被子类覆盖。第二个 `Equals` 是静态方法，以 `Object.Equals(objA, objB)` 的形式调用。其逻辑会转发到 `operator==` 或 `objA.Equals`。
3. `public virtual`。
4. 无。
5. 构造方法为空；没有析构函数。

## `System.Type`

6. `protected`。
7. 因为构造方法受保护，不可以直接访问。
8. `GetFields` 返回该类型的所有字段信息；`GetMethods` 返回该类型的所有方法信息；`GetProperties` 返回该类型的所有属性信息；`GetEvents` 返回该类型的所有事件信息。

## `System.String`

9. 否。
10. `String` 实现了 `IComparable` 和 `ICloneable` 接口。
11. 判断 `values` 是否为空、`separator` 是否为空。
12. `String` 是不可变类型。每次为其重新赋值，都会创建新的实例。`StringBuilder` 其内部的存储空间是可变的。
13. 每次为其重新赋值，都会创建新的实例。`Replace` `Append` `Trim` 方法，都不改变字符串自己的值。
14. 将所有位于小写字母区间的单个字符，减去 `0x20`，即得到了对应的大写字母。该函数内使用了落指针，故声明为 `unsafe`。
15. 内容相等。`operator ==` 调用 `Equals` 方法；该方法调用 `EqualsHelper` 方法；该方法逐字符比较内容。
16. `public extern char this[int index]`。
17. 静态方法，判断某个对象是否为空，或者空字符串。
18. `System.Object`。效率高。
19. `Convert` 类的 `ToDouble` 方法。

## `System.Text.StringBuilder`

20. 16。
21. `get` 方法返回当前可用的容量，`set` 方法修改可用的容量。扩展`value - m_ChunkOffset` 个字节，前者是调用参数，后者是当前块的空间。
22. 返回 `this`。好处是可以链式调用。

## `System.Double`

23. `struct`。它实现了 `IComparable, IFormattable, IConvertible, IComparable<Double>, IEquatable<Double>`。
24. （不考虑常量和静态数据的前提下，）1 个，使用 `internal` 修饰。
25. `public`；`1.7976931348623157E+308`。
26. 待比较数为空、待比较数小于当前数、当前数为 NaN 时，返回 1；待比较数大于当前数、待比较数为 NaN 时，返回 -1；当前数等于待比较数（含 NaN）时，返回 0。
27. `System.Object`；相等。
28. `public static bool operator ==(Double left, Double right) { return left == right; }`。
29. 将值 `m_value` 的高 32 位和低 32 位异或，即得到散列码。

## `System.Convert`

30. 该类是静态类。
31. 前者不调用任何方法；后者调用 `Double.parse` 方法。

## `System.Math`

32. 当值为 `Int16.MinValue` 时。
33. `Acos` `Cos` `Floor` 等。

## `System.Random`

34. 使用 `Environment.TickCount` 初始化种子。
35. `Next` 间接调用 `InternalSample`，其从种子生成的随机序列中产生值。

## `System.Array`

36. `FunctorComparer` `SZArrayEnumerator` `ArrayEnumerator`。
37. `IntrospectiveSort` 或 `DepthLimitedQuickSort`。

## `System.Collections.Generic.List<T>`

38. 翻一倍。

## `System.Collections.Generic.Stack<T>`

39. `Push` 向内部数组添加有效元素；若数组长度不够，则重新分配内存病复制原有元素；`Pop` 将末尾的有效元素标记为无效，并使用默认值覆盖。

## `System.Collections.Hashtable`

40. `public virtual Object this[Object key]`。

## `System.Net.WebClient`

41. 没有关系。逻辑上，`WebClient` 负责创建 `WebRequest`。
42. 首先，获取 HTTP 头中，`Content-Type` 的 `charset` 属性。若无，则测试是否包含 UTF-8/UTF-32/UTF-16 LE/UTF-16 BE 的 BOM。若无，则使用默认编码（操作系统 ACP）。
