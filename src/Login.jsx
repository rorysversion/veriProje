// import React from "react";
// import "./App.css";

// const Login = () => {
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
// };

// export default Login;













// import React from "react";
// import { useNavigate } from "react-router-dom";

// const Login = () => {
//   const navigate = useNavigate();

//   const handleStudentClick = () => {
//     navigate("/student");
//   };

//   const handleTeacherClick = () => {
//     navigate("/teacher");
//   };

//   return (
//     <div className="login-container">
//       <h2>Login</h2>
//       <div className="icons">
//         <div onClick={handleStudentClick} style={{ cursor: "pointer" }}>
//           <img
//             src="/student-icon.png" // Public klasöründeki ikon
//             alt="Student"
//             width="50"
//           />
//         </div>
//         <div onClick={handleTeacherClick} style={{ cursor: "pointer" }}>
//           <img
//             src="/advisor-icon.png" // Public klasöründeki ikon
//             alt="Teacher"
//             width="50"
//           />
//         </div>
//       </div>
//       <form>
//         <input type="text" placeholder="Enter your username" />
//         <input type="password" placeholder="Enter your password" />
//         <button type="submit">Login</button>
//       </form>
//     </div>
//   );
// };

// export default Login;