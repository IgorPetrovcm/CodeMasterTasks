namespace GatesController.Core
{
    public class GatesManager
    {
        object? lockObject = new object();
        
        private readonly ILogger _logger;

        private GateStatus[] _gates = new GateStatus[5];

        // Count of visitors at the moment
        private int _visitorsCount = 0;

        // Count of visitors at the moment by the gate they used to enter
        private int[] _visitorsByGates = new int[5];

        public GatesManager(ILogger<GatesManager> logger)
        {
            _logger = logger;
        }

        // Do not modify
        public int VisitorsCount => _visitorsCount;

        // Do not modify
        public int[] VisitorsByGates => _visitorsByGates;

        // Do not modify
        public GateStatus[] GetOpenGates() => _gates;

        // Open Request logic
        public async Task RequestOpen(int gateId)
        {
            lock(lockObject)
            {
                if (gateId < 0 || gateId > 5)
                {
                    _logger.LogInformation("There is no gate with this id");
                    return;
                }

                int gatesOpenCount = 0;
                int gateOpen = 0;

                for (int i = 0; i < _gates.Length; i++)
                {
                    if (_gates[i] == GateStatus.Open)
                    {
                        gateOpen = i + 1;
                        gatesOpenCount++;
                    }
             }

                if (gatesOpenCount == 2)
                {
                    _logger.LogInformation("You will not be able to open more gates");
                    return;
                }

                if (gateId == gateOpen + 1 || gateId == gateOpen - 1)
                {
                    _logger.LogInformation("The neighboring gate cannot be opened");
                }   
            
                _logger.LogInformation("Received open request for Gate {GateId}", gateId);

            // We need to set the Status to waiting in case the gate is blocked
            // _gates[gateId - 1] = GateStatus.Waiting;
                _gates[gateId - 1] = GateStatus.Open;  // Make sure we set correct status for Dashboard to work

                _logger.LogInformation("Gate {GateId} is open", gateId);
            }
        }

        // Close Request logic
        public async Task RequestClose(int gateId)
        {
            lock (lockObject)
            {
                if (gateId < 0 || gateId > 5)
                {
                    _logger.LogInformation("There is no gate with this id");
                    return;
                }

                _logger.LogInformation("Received close request for Gate {GateId}", gateId);

                _logger.LogInformation("Gate {GateId} is closed", gateId);

                _gates[gateId - 1] = GateStatus.Closed; // Make sure we set correct status for Dashboard to work
            }
        }

        // Register Enter Request
        public void RegisterVisitorEnter(int gateId)
        {
            lock (lockObject)
            {
                if (gateId < 0 || gateId > 5)
                {
                    _logger.LogInformation("There is no gate with this id");
                    return;
                }
                _visitorsCount++;
                _visitorsByGates[gateId - 1]++;
            }
        }

        // Register Leave Request
        public void RegisterVisitorLeave(int gateId)
        {
            lock (lockObject)
            {
                if (gateId < 0 || gateId > 5)
                {
                    _logger.LogInformation("There is no gate with this id");
                    return;
                }

                if (_visitorsByGates[gateId - 1] <= 0)
                {
                    _logger.LogInformation("The number of visitors is zero");
                    return;
                }

                _visitorsCount--;
                _visitorsByGates[gateId - 1]--;
            }
        }
    }
}
