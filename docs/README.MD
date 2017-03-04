# [关于DOTNETLIVE(DNL)](./)

本项目围绕微软最新的.NET Core 跨平台技术，设定的一个虚拟大项目(包括单点登陆系统(SSO), 综合博客(类似博客园), 论坛, 问答社区，考试系统(大家可以出题，大家可以答题),及其他你认为有意义的项目, 我们全力支持,秉承一切交给社区)，通过完成项目的功能来达到.NET Core落地实践的目的.

这个虚拟项目坚持开放的原则，包容的姿态，为大家建立以代码为基础的交流渠道, 建立统一的业务沟通背景, 而不仅仅停留在讲理论的层面; 

TALK IS CHEAP, SHOW ME YOUR CODE!

***

QQ群: 191870871 (.NET Core落地实践)

这里有.net core, angular2, vue, react各路牛人，同时也欢迎你加入，一起来开发一个面向互联网的，有意思的大型系统, 向更多的人展示我们自己.

Welcome To Join DNL Team!

***

## .NET Core版本与环境
我们得项目会紧跟.NET Core官方的版本, 最新的环境可以在下面地址找到 [.NET Core发布公告](https://github.com/dotnet/core/tree/master/release-notes)

* DNL项目当前使用版本
我们目前采用.NET Core RC4版本进行项目开发[下载页面](https://github.com/dotnet/core/blob/master/release-notes/rc4-download.md)

* 安装问题
通常我们只需要安装.NET Core的SDK就好，SDK是包含了Runtime的.

## DHL项目开发环境要求说明

* 必须是VS2017 RC3以上版本(重要的事说三遍)
* VS2017 RC3以下及VS2015等版本是否可以? 请参考上一条.
* .net core tools 版本必须是1.0.0-rc4-004757版本往上, 有人问怎么查看这个版本号，在命令行底下输入 dotnet -\-version(备注,vesion前面是双横向)

## 目录分类

* [架构](/architecture/)
* [规范](/specification/)
* [开发](/development/)
* [部署(https://github.com/dotnetlive/dotnetlive/tree/master/deployment)](https://github.com/dotnetlive/dotnetlive/tree/master/deployment)

## 相关站点地址:

GITHUB地址:([hhttps://github.com/dotnetlive](https://github.com/dotnetlive))

DNL主站:([https://dotnet.live](https://dotnet.live))

DNL登陆站:([http://account.dotnet.live](http://account.dotnet.live)) --负责登陆认证

DNL论坛站:([http://forums.dotnet.live](http://forums.dotnet.live)) --开辟各种板块，话题讨论

DNL博客站:([http://blog.dotnet.live](http://blog.dotnet.live)) --小小的笔记或者某次深思的记录

DNL考试站:([http://exam.dotnet.live](http://exam.dotnet.live)) --享受问答的乐趣

DNL搜索站:([http://search.dotnet.live](http://exam.dotnet.live)) --享受问答的乐趣

## DNL站点目前部署情况
目前DNL所有站点部署在一台Linux Debian服务器上

## QQ群讨论注意事项
1. 除了常规的沟通协作，所有有关项目的业务问题，技术问题请转移到Github Issue里面