import Login from './Auth/Login';
import Register from './Auth/Register';
import Home from './Home';
import RouteGuard from './Util/RouteGuard'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import QuizList from './Quiz/QuizList';
import CreateQuiz from './Quiz/CreateQuiz';
import ApprovalRequest from './Quiz/ApprovalRequest';
import AppLayout from './AppLayout';
import Logout from './Auth/Logout';
import './App.css';


const App = () => {
  return (
    <Router>
      <Routes>
        <Route element={<AppLayout />}>
          <Route exact path="/" element=
            {
              <RouteGuard component={Home} />
            }/>
          <Route exact path="/quiz-list" element=
            {
              <RouteGuard component={QuizList} />
            }/>
          <Route exact path="/create-quiz" element=
            {
              <RouteGuard component={CreateQuiz} />
            }/>
          <Route exact path="/requests" element=
            {
              <RouteGuard component={ApprovalRequest} />
            }/>
          <Route exact path="/logout" element=
            {
              <RouteGuard component={Logout} />
            }/>
        </Route>
        <Route exact path="/login" element={<Login/>}/>
        <Route exact path="/register" element={<Register/>}/>
      </Routes>
    </Router>
  );
};

export default App;