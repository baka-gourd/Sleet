import { Reducer, Action } from "redux";

export interface ProjectPageState {
  word: string;
  projects: string[];
  displayProjects: string[];
}
export interface GetListAction {
  type: "GET_LIST";
}

export interface FilterListAction {
  type: "FILTER_LIST";
}

export interface SetWordAction {
  type: "SET_WORD";
  word: string;
}

export type KnownAction = GetListAction | FilterListAction | SetWordAction;

export const actionCreators = {
  getList: () => ({ type: "GET_LIST" } as GetListAction),
  filterList: () => ({ type: "FILTER_LIST" } as FilterListAction),
  setWord: (word: string) =>
    ({ type: "SET_WORD", word: word } as SetWordAction),
};

export const reducer: Reducer<ProjectPageState> = (
  state: ProjectPageState | undefined,
  incomingAction: Action
): ProjectPageState => {
  if (state === undefined) {
    const projectChildren = ["114", "214", "31919", "42345", "5"]
    return {
      projects: projectChildren,
      displayProjects: projectChildren,
      word: "",
    };
  }

  const action = incomingAction as KnownAction;
  switch (action.type) {
    case "GET_LIST":
      return { ...state, projects: ["114", "214", "31919", "42345", "5"] };
    case "FILTER_LIST":
      const filtered = state.projects.filter((str) => {
        return str.indexOf(state.word) !== -1;
      });
      return { ...state, displayProjects: filtered };
    case "SET_WORD":
      return { ...state, word: action.word };
    default:
      return state;
  }
};
