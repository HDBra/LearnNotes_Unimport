将一个wpf程序设置为不显示：
Width = Height = MaxHeight = MaxWidth = 0;
WidowStyle = None//不显示最大最小化按钮
ShowInTaskbar = false //在任务栏和任务管理器应用程序列表中不显示
this.WindowState = Minimized//最小化显示
this.WindowStartupLocation = WindowStartupLocation.Manual;
this.Left = -1000;//设置显示位置
this.Top = -1000;