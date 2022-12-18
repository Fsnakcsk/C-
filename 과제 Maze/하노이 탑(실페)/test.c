#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long long fib(int n) {

	int tmp, current=1, last=0, i;
	
	for(i=2; i<=n; i++) {
		tmp = current;
		current += last;
		last = tmp;
	}
	return current;
}

main()
{
	clock_t stratTime, finishTime; 
	double duration;
	
	stratTime = clock();
	printf("%lld",fib(505));
	finishTime = clock();
	
	duration = (double) (finishTime - stratTime) / CLOCKS_PER_SEC;
	printf("수행시간 : %f 초\n",duration);
}
