////////////////////////////////////////////////////////////////////
//
// Lab 3 -  Sequential program to print prime number
//       Convert to multi-threading
// (demo code by Foo Lye Heng) - 20230301
//      
////////////////////////////////////////////////////////////////////

#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>					// Include pthread.h

void  *primeNumberPrint( void *ptr )  {

   long num = (long) ptr;
   printf("Blah blah blah ... running for %ld ... blah blah blah\n", num);
   return NULL;
}

int main()
{
    int count;
 	pthread_t thread_id[1000];                      // Initialize thread_id array

    printf("Enter count [1 - 1000]: ");
    scanf("%d", &count);

    for ( int i = 0; i < count; i++ ) {
      // Generate a random number between 0 and 5000
      long randomnum = (long) rand() % 10000;

      //primeNumberPrint( (void *) randomnum);
      pthread_create(&thread_id[i], NULL, primeNumberPrint, (void *) randomnum);
    }
    
    // Wait for all the threads to finish
    for ( int i = 0; i < count; i++ ) {
      pthread_join(thread_id[i], NULL);
    }

    exit(0);
}

