import './App.css';

function App() {
  return (
    <div className="App">
      <div class="box h-100vh">
        <div class="App-header grid place-content-center">
          <h1>Rocket Repair</h1>
        </div>
        <div className='App-content-bg'>
          <div className="App-content">
            <a className='App-download' href={`https://localhost:5001/downloads/v/1.0.0`} download>Download VR demo</a>
          </div>
        </div>
        <div class="App-footer grid grid-cols-1 justify-end justify-items-end pr-5">
            <p>A collaboration from <a className="text-violet-500" href={`https://github.com/aboveavgdev`}>aboveavgdev</a> and <a className="text-violet-500" href={`https://github.com/service-fabric-dev`}>servicefabricdev</a></p>
        </div>
      </div>
    </div>
  );
}

export default App;
