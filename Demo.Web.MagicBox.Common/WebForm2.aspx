<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Demo.Web.MagicBox.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--<script type="text/javascript">
        //打印工作薄
        var idTmr = "";
        function xlPrint() {
            var filepath = "http://localhost/Demo.Web.MagicBox./resource/工票批20141119045605496.xls"; //文件路径
            var xlApp; //存放Excel对象
            var XlBook; //存放Excel工作薄文件
            var xlSheet; //存放Excel活动工作表
            try {
                xlApp = new ActiveXObject("Excel.Application");
            } catch (e) {
                alert("请启用ActiveX控件");
                return;
            }
            xlBook = xlApp.Workbooks.open(filepath);
            xlBook.PrintOut; //工作薄打印
            xlBook.Close(true);
            xlApp.Quit;
            xlApp=null;	
            //防Excel死进程的关键！！必须！！！downmoon严重声明
            idTmr = window.setInterval("Cleanup();", 1000);
        }
        function Cleanup() {
            window.clearInterval(idTmr);
            CollectGarbage();
        }</script>-->
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <button onclick="xlPrint()" style="width: 147px" >点击测试打印excel
        </button>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="测试打印excel1" />
    </div>
    </form>
</body>
</html>
