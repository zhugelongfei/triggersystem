# Trigger system for unity(C#)

# 介绍
TS系统（指触发器系统）是一个基于C#语言实现的根据不同的条件触发不同行为的代码框架。
此工程为Unity Package的Git包，可通过Unity的PackageManagerWindow导入到需要使用的项目中。

# 使用方法
- 在Unity中点击菜单栏的Window->Package Manager打开PackageManager面板
- 点击Add package from git url
- 复制git工程的http地址，粘贴到输入栏
- 点击Add

# 应用场景
- 游戏中玩家单位进入指定区域（条件），触发开启一个陷阱（行为）
- 游戏中玩家单位血量低于百分之30（条件）或进入眩晕状态（条件），触发显示UI预警框（行为）
- ...
# 框架结构图
![Frame](/Images/Frame.png)

| Module | Base Class | README |
| ------ | ------ | ------ |
| Condition | ABaseCondition | 执行进入函数时注册监听条件达成的事件，退出时注销。当条件触发时，设置IsSuccess为true |
| Action | ABaseAction | 进入时开始行为，退出时结束行为 |
| Event | ABaseEvent |Action的派生类，重写DoAction函数，可实现触发时立即执行行为（不需要退出函数的行为可使用此类作为基类） |
| ConditionsMgr | ABaseCondMgr | 用来描述如何达成触发条件 |
| ActionsManager | ABaseActMgr | 用来描述触发后，如何执行行为 |
| Trigger | ABaseTrigger | 管理条件管理器和行为管理器的合作方式。|

# ConditionsMgr
| Class | README |
| ------ | ------ |
| CondMgr_TotalSucc.cs | 全部条件达成触发 |
| NotImplemented | 任意一个条件达成触发 |
| ... | ... |

# ActionsMgr
| Class | README |
| ------ | ------ |
| ActMgr_TotalEnter.cs | 执行全部行为 |
| NotImplemented | 随机执行一条行为 |
| ... | ... |

# Trigger
| Class | README |
| ------ | ------ |
| Trigger_CA.cs | 条件达成后，触发行为 |
| Trigger_CAC.cs | 开始条件达成后，进入结束条件检测，并触发行为，结束条件达成时，行为结束 |
| ... | ... |

如上所示，几乎所有模块都可以继承来实现不同的逻辑。不同的条件组合触发不同的行为。

> Note：由于运行时序问题，CondMgr不能在进入时判断条件已达成而立即进行触发，故而需要由上层Trigger在Update中判断条件是否达成，来进行状态切换。
