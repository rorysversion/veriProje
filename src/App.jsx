// import { useState } from 'react'
// import React from "react";
// import "./App.css";

import React, { useState } from "react";
import "./App.css";
import "./Student.css";
const App = () => {
  const [userType, setUserType] = useState(null);

  // Kullanıcı tipi seçildiğinde çağrılır
  const handleUserType = (type) => {
    setUserType(type);
  };

  const renderPage = () => {
    if (userType === "student") {
      return <h1>Welcome to the Student Page!</h1>;
    } else if (userType === "teacher") {
      return <h1>Welcome to the Teacher Page!</h1>;
    } else {
      return (
        <div className="login-container">
          <div className="login-box">
            <h2>Login</h2>
            <div className="user-type">
              <div
                className="user-option"
                onClick={() => handleUserType("student")}
              >
                <img src="student-icon.png" alt="Student" />
                <p>Student</p>
              </div>
              <div
                className="user-option"
                onClick={() => handleUserType("teacher")}
              >
                <img src="advisor-icon.png" alt="Teacher" />
                <p>Teacher</p>
              </div>
            </div>
            <form>
              <input type="text" placeholder="Enter your username" required />
              <input type="password" placeholder="Enter your password" required />
              <button type="submit">Login</button>
            </form>
            <a href="/forgot-password" className="forgot-password">
              Forgot Password
            </a>
            <footer>&copy; 2024 - SmartCourseSelector</footer>
          </div>
        </div>
      );
    }
  };

  return <div>{renderPage()}</div>;
};

export default App;


//------------------------------------
// import React from "react";
// import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
// import Login from "./Login"; // Login bileşeni
// import StudentPage from "./StudentPage"; // Öğrenci sayfası
// import TeacherPage from "./TeacherPage"; // Öğretmen sayfası
// import "./App.css";
// import "./Student.css";
// const App = () => {
//   return (
//     <Router>
//       <Routes>
//         <Route path="/" element={<Login />} />
//         <Route path="/student" element={<StudentPage />} />
//         <Route path="/teacher" element={<TeacherPage />} />
//       </Routes>
//     </Router>
//   );
// };

// export default App;

//-----------------------------------------------------------------------------------------
// import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
// import Login from "./Login"; // Login bileşeni
// import StudentPage from "./StudentPage"; // Öğrenci sayfası
// import TeacherPage from "./TeacherPage"; // Öğretmen sayfası

// const App = () => {
//   return (
//     <Router>
//       <Routes>
//         <Route path="/" element={<Login />} />
//         <Route path="/student" element={<StudentPage />} />
//         <Route path="/teacher" element={<TeacherPage />} />
//       </Routes>
//     </Router>
//   );
// };



//-----------------------------------------
// function App() {
//   return (
  
//     <div className="login-container">
//       <div className="login-box">
//         <h2>Login</h2>
//         <div className="user-type">
//           <div className="user-option">
//             <img src="student-icon.png" alt="Student" />
//             <p>Student</p>
//           </div>
//           <div className="user-option">
//             <img src="advisor-icon.png" alt="Advisor" />
//             <p>Advisor</p>
//           </div>
//         </div>
//         <form>
//           <input type="text" placeholder="Enter your username" required />
//           <input type="password" placeholder="Enter your password" required />
//           <button type="submit">Login</button>
//         </form>
//         <a href="/forgot-password" className="forgot-password">
//           Forgot Password
//         </a>
//         <footer>&copy; 2024 - SmartCourseSelector</footer>
//       </div>
      
//     </div>
  
//   );
// }

// export default App;