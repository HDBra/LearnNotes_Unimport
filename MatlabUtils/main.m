a = [1 2 3];
n = 50;
r = rand(n,1);
plot(r);
m = mean(r);
hold on
plot([0,n],[m,m]);
hold off
title('Mean of random uniform data');
