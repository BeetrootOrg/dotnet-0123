using ConsoleApp;

SingleResponsibility.CheckPositiveBad(-1);
SingleResponsibility.CheckPositiveGood(-1);

LiskovBaseBad b = new LiskovDerivedBad();
b.DoSomething();

LiskovBaseGood g = new LiskovDerivedGood();
g.DoSomething();