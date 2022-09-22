using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

ScriptEngine engine = Python.CreateEngine();
ScriptScope scope = engine.CreateScope();
string testText = "Заместитель начальника организационно-экономического отдела управления Пенсионного фонда Иван Семенович Гостюхин (+71234567890, i.s.gostiuhin@gmail.com).\r\nОперативный сотрудник 3 отдела полиции Злобин О.П. (89876543210).\r\nПреподаватель Пензенского государственного университета Замотин Георгий Сергеевич (+71029384756).\r\nАнтонов Григорий Васильевич (+71134567890, gvantonov@mail.ru)";

engine.ExecuteFile(path: "C:\\Users\\Gemenee\\source\\repos\\PythonTextApp\\PythonTextApp\\Extractor\\extractor.py", scope);
dynamic extract_facts = scope.GetVariable("extract_facts");
//dynamic init_extractor = scope.GetVariable("init_extractor");
//dynamic result = extract_facts(testText);

Console.WriteLine(result);