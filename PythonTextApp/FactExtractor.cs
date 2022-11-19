using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace YargyExtractionCore;

public class FactExtractor
{
    private const string testText =
        "Заместитель начальника организационно-экономического отдела управления Пенсионного фонда Иван Семенович Гостюхин (+71234567890, i.s.gostiuhin@gmail.com).\r\nОперативный сотрудник 3 отдела полиции Злобин О.П. (89876543210).\r\nПреподаватель Пензенского государственного университета Замотин Георгий Сергеевич (+71029384756).\r\nАнтонов Григорий Васильевич (+71134567890, gvantonov@mail.ru)";

    private ScriptEngine _engine;
    private ScriptScope _scope;

    public FactExtractor()
    {
        _engine = Python.CreateEngine();
        _scope = _engine.CreateScope();
    }

    public string Extract()
    {
        var searchPaths = _engine.GetSearchPaths();
        searchPaths.Add("..\\..");
        searchPaths.Add(@"C:\Users\Gemenee\source\repos\PythonTextApp\PythonTextApp\Extractor");
        searchPaths.Add("..\\..\\..\\PythonTextApp\\Extractor");
        searchPaths.Add(@"C:\Users\Gemenee\AppData\Local\Programs\Python\Python310\Lib\site-packages\");
        _engine.SetSearchPaths(searchPaths);
        
    
        
        _engine.ExecuteFile(
            path: "..\\..\\..\\..\\PythonTextApp\\Extractor\\extractor.py", _scope);
        
        ScriptSource pythonScript = _engine.CreateScriptSourceFromFile("..\\..\\..\\..\\PythonTextApp\\Extractor");

        //pythonScript.Execute();
        
        dynamic extract_facts = _scope.GetVariable("extract_facts");

        //dynamic init_extractor = scope.GetVariable("init_extractor");
        dynamic result = extract_facts(testText);

        Console.WriteLine(result);
        return result;
    }
}