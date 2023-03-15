// See https://aka.ms/new-console-template for more information
using Matrixs;

var A = new Matrix();
A.ReadRandom(3, 2);
A.Write();
var B = new Matrix();
B.ReadRandom(2, 3);
B.Write();
var C = A * B;
C.Write();