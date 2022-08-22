import { Route, Switch, useLocation } from 'react-router-dom';
import Menu from './components/Menu';
import Home from './components/Home';

import './App.css';

function App() {
  return (
    <div className="flex flex-col h-full">
      <Menu />
      <div id="main" className="h-full overflow-y-auto">
        <Switch>
          <div className="md:max-w-screen-xl md:m-auto">
            <Route path="/home">
              <Home/>
            </Route>
          </div>
        </Switch>
        <Switch>
          <Route exact path="/">
          </Route>
        </Switch>
      </div>
    </div>
  );
}

export default App;
