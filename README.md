# ChineseNumberConvert

将中文数字转换为阿拉伯数字

example: 三千六百亿四千七百二十万零二百二十二 -> 3600 4720 0222

## 对应的设计模式

解释器模式

## 注意

中文的书写必须满足规范

单位（亿，万，千，百，十）前面，必须有数字。

| 中文   | 是否合法           |
|-------|------------------|
| 一十   | 合法               |
| 一十一 | 合法               |
| 十     | 不合法(已额外处理) |
| 十一   | 不合法(已额外处理) |

`ChineseNumberConverter` 中已经对以单位开头的做了预处理，但最好还是按照规范书写中文。

## 使用示例

``` csharp

string str = "三千六百亿四千七百二十万零二百二十二";

var converter = new ChineseNumberConverter();
long number = converter.Convert(str);

```
