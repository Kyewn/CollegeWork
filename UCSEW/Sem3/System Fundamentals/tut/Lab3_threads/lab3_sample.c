////////////////////////////////////////////////////////////////////
//
// Lab 3 -  Sequential program to print prime number
// (demo code by Foo Lye Heng) - 20230301
//      
////////////////////////////////////////////////////////////////////

#include <stdio.h>
#include <stdlib.h>

void  *primeNumberPrint( void *ptr )  {

   long num = (long) ptr;
   printf("Blah blah blah ... running for %ld ... blah blah blah\n", num);
   return NULL;
}

int main()
{
    int count;

    printf("Enter count: ");
    scanf("%d", &count);

    for ( int i = 0; i < count; i++ ) {
      // Generate a random number between 0 and 5000
      long randomnum = (long) rand() % 5000;

      primeNumberPrint( (void *) randomnum);

    }

    exit(0);
}

