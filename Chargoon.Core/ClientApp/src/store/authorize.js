const authTrue = 'AUTH_TRUE';
const authFalse = 'AUTH_FALSE';
const initialState = { auth: false };

export const actionCreators = {
    authTrue: () => ({ type: authTrue }),
    authFalse: () => ({ type: authFalse })
};

export const reducer = (state, action) => {
  state = state || initialState;
    console.log(action)

  if (action.type === authTrue) {
    return {auth:true};
  }

  if (action.type === authFalse) {
    return {auth:false};
  }

  return state;
};
