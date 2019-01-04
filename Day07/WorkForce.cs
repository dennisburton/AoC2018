using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    public class WorkForce {
        public List<Worker> Workers {get; set;} = new List<Worker>();

        public void PrepareWorkForce( int numberOfWorkers ){
            for(var workerIndex=0; workerIndex<numberOfWorkers; workerIndex++ ){
                Workers.Add( new Worker{Id=workerIndex+1});
            }
        }

        public Worker NextAvailableWorker(){
            return Workers.OrderBy( worker => worker.availableSecond ).First();
        }

        public List<Worker> AvailableAt(int second){
            return Workers.Where( worker => worker.availableSecond <= second )
                          //.OrderBy( worker => worker.availableSecond )
                          .OrderBy( worker => worker.Id)
                          .ToList();
        }
    }
}
