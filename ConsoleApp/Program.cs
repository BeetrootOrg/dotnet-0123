
Console.WriteLine(MMax(1,2));
Console.WriteLine(MMin(3,2));
bool f=TrySumIfOdd(4,5,out int sum);
Console.WriteLine($"result {f} summ {sum}");
Console.WriteLine(Repeat("str",3));

static int MMax(int val1,int val2){
    return Math.Max(val1,val2);
}
int MMin(int val1,int val2){
    return Math.Min(val1,val2);
}
bool TrySumIfOdd(int val1,int val2,out int sum){
    sum=val1+val2;
    if (sum%2==0) return true; else return false;
} 
// int MMax(int val1,int val2,int val3){
//     int result=Math.Max(val1,val2);
//     result=Math.Max(result,val3);
//     return result;
// }
// int MMin(int val1,int val2,int val3){
//     int result=Math.Min(val1,val2);
//     result=Math.Min(result,val3);
//     return result;
// }
// int MMax(int val1,int val2,int val3,int val4){
//     int result=Math.Max(val1,val2);
//     result=Math.Max(result,val3);result=Math.Max(result,val4);
//     return result;
// }
// int MMin(int val1,int val2,int val3,int val4){
//     int result=Math.Min(val1,val2);
//     result=Math.Min(result,val3); result=Math.Min(result,val4);
//     return result;
// }
string Repeat (string x,int num){
    num=num-1;
    if (num>0) return  x+Repeat(x,num);
    return x;
}