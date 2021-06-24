import { Reducer, Action } from "redux";

export interface ProjectPageState {
  page: number;
  projects: number[];
}

export interface NextPageAction {
  type: "NEXT_PAGE";
}
export interface PrevPageAction {
  type: "PREV_PAGE";
}
export interface GetListAction {
  type: "GET_LIST";
}

export type KnownAction = NextPageAction | PrevPageAction | GetListAction;

export const actionCreators = {
  next: () => ({ type: "NEXT_PAGE" } as NextPageAction),
  prev: () => ({ type: "PREV_PAGE" } as PrevPageAction),
  getList: () => ({ type: "GET_LIST" } as GetListAction),
};

export const reducer: Reducer<ProjectPageState> = (
  state: ProjectPageState | undefined,
  incomingAction: Action
): ProjectPageState => {
  if (state === undefined) {
    return { page: 1, projects: [1, 2, 3, 4, 5] };
  }

  const action = incomingAction as KnownAction;
  switch (action.type) {
    case "NEXT_PAGE":
      console.log(state.page);
      return { ...state, page: state.page + 1 };
    case "PREV_PAGE":
      console.log(state.page);
      if (state.page === 1) return state;
      return { ...state, page: state.page - 1 };
    case "GET_LIST":
      return { ...state, projects: [1, 2, 3, 4, 5, 6, 7] };
    default:
      return state;
  }
};
