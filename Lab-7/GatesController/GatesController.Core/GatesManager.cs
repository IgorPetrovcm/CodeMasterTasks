namespace GatesController.Core
{
    public class GatesManager
    {
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
            _logger.LogInformation("Received open request for Gate {GateId}", gateId);

            // We need to set the Status to waiting in case the gate is blocked
            // _gates[gateId - 1] = GateStatus.Waiting;
            _gates[gateId - 1] = GateStatus.Open;  // Make sure we set correct status for Dashboard to work

            _logger.LogInformation("Gate {GateId} is open", gateId);
        }

        // Close Request logic
        public async Task RequestClose(int gateId)
        {
            _logger.LogInformation("Received close request for Gate {GateId}", gateId);

            _logger.LogInformation("Gate {GateId} is closed", gateId);

            _gates[gateId - 1] = GateStatus.Closed; // Make sure we set correct status for Dashboard to work
        }

        // Register Enter Request
        public void RegisterVisitorEnter(int gateId)
        {
            _visitorsCount++;
            _visitorsByGates[gateId - 1]++;
        }

        // Register Leave Request
        public void RegisterVisitorLeave(int gateId)
        {
            _visitorsCount--;
            _visitorsByGates[gateId - 1]--;
        }
    }
}
