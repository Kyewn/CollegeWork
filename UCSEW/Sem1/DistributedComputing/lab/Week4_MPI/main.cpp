#include <mpi.h>
using namespace std;

int main() {
    int noOfProcess, processNo;
    
    MPI_Init(NULL, NULL);
    MPI_Comm_size(MPI_COMM_WORLD, &noOfProcess);
    MPI_Comm_rank(MPI_COMM_WORLD, &processNo);
    
    printf("Hello world! I am %d of %d\n", processNo, noOfProcess);
    
    MPI_Finalize();

    return 0;
}