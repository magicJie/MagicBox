//��ӡ������
var idTmr = "";
function xlPrint(path) {
    var xlApp; //���Excel����
    var XlBook; //���Excel�������ļ�
    var xlSheet; //���Excel�������
    try {
        xlApp = new ActiveXObject("Excel.Application");

    } catch (e) {
        alert("������ActiveX�ؼ�");
        return;
    }
    xlBook = xlApp.Workbooks.open(path);
    xlBook.PrintOut; //��������ӡ
    xlBook.Close(true);
    xlApp.Quit;
    xlApp = null;
    //��Excel�����̵Ĺؼ��������룡����downmoon��������
    idTmr = window.setInterval("Cleanup();", 1000);
}
function Cleanup() {
    window.clearInterval(idTmr);
    CollectGarbage();
}