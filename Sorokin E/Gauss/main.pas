Program HelloWorld(output);
var a, b, x, answer: real;
var i: integer;
var beta: array [1..4] of real = (
    0.173927,
    0.326073,
    0.326073,
    0.173927);
var alpha:  array [1..4] of real = (
    0.069432, 
    0.33001,
    0.66999,
    0.930568);
begin
    a := 0;
    b := Pi / 2.0;
    answer := 0;
    
     for i:=1 to 4 do
        begin
            x := a + (b - a) * alpha[i];
            answer := answer + beta[i] * sin(x);
        end;
    
    answer := answer * (b - a);   
    
    writeln(answer);
end.
