Program Gauss4Node(output);
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

function my_function(x: real): real;
begin
    my_function := sin(x);
end;

begin
    a := 0;
    b := Pi / 2.0;
    answer := 0;
    
     for i:=1 to 4 do
        begin
            x := a + (b - a) * alpha[i];
            answer := answer + beta[i] * my_function(x);
        end;
    
    answer := answer * (b - a);   
    
    writeln(answer);
end.
