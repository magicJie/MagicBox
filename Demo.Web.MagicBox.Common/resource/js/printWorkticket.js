//打印工作薄
var idTmr = "";
function xlPrint(path) {
    var xlApp; //存放Excel对象
    var XlBook; //存放Excel工作薄文件
    var xlSheet; //存放Excel活动工作表
    try {
        xlApp = new ActiveXObject("Excel.Application");

    } catch (e) {
        alert("请启用ActiveX控件");
        return;
    }
    xlBook = xlApp.Workbooks.open(path);
    xlBook.PrintOut; //工作薄打印
    xlBook.Close(true);
    xlApp.Quit;
    xlApp = null;
    //防Excel死进程的关键！！必须！！！downmoon严重声明
    idTmr = window.setInterval("Cleanup();", 1000);
}
function Cleanup() {
    window.clearInterval(idTmr);
    CollectGarbage();
}