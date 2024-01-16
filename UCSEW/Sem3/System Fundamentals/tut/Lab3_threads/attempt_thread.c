#include "pthread.h"
#include "stdio.h"
#include "time.h"
#include "stdlib.h"
#include "math.h"

pthread_mutex_t lock;

void* printPrimeOfRandom() {
	//Implementation
	pthread_mutex_lock(&lock);
	// 0 and 1 are not prime numbers
	// change flag to 1 for non-prime number
	  int n = rand() % 20;
	  printf("Prime numbers of %d are:\n", n);
	  if (n == 0 || n == 1) {
	    printf("None!\n");
	  } else {
		for(int i = 2; i <= n; i++) {
		    if (i == 2) {
		 	printf("2\n");
		 	continue;
		    }
		    for (int j = 2; j <= i-1; j++) {
		    // if n is divisible by i, then n is not prime
		    // change flag to 1 for non-prime number
		    int isPrime = 0;
		    if (i % j == 0) {
		       break;
		    }
		    printf("%d\n", i);
		    break;
		   }
		}
	  }
	pthread_mutex_unlock(&lock);
	return NULL;
}

void createRandomPrimeThread(pthread_t* randomPrimeThread) {
	pthread_create(randomPrimeThread, NULL, &printPrimeOfRandom, NULL);
}

int main() {
	srand(time(NULL));
	pthread_mutex_init(&lock, NULL);

	int threadNo;
	// Ask for thread number
	printf("Enter amount of threads to run: ");
	scanf("%d", &threadNo);
	printf("\nThreads number: %d\n", threadNo);

	pthread_t threadArr[threadNo];

	for (int i=0; i< threadNo; i++) {
		createRandomPrimeThread(&threadArr[i]);
	}
	for (int i=0; i< threadNo; i++) {
		pthread_join(threadArr[i], NULL);
	}
	pthread_mutex_destroy(&lock);
	printf("COMPLETE");
	exit(0);
}

