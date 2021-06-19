import { Action,Reducer } from "redux";

export interface ProjectCardState{
    imageUrl: string,
    projectName: string,
    projectDescription: string,
    isLock:boolean,
}

export interface LockProjectAction { type: 'LOCK_PROJECT' };
export interface UnlockProjectAction { type: 'UNLOCK_PROJECT' };

export type KnownAction = LockProjectAction | UnlockProjectAction;

export const actionCreators = {
    lock: () => ({ type: 'LOCK_PROJECT' } as LockProjectAction),
    unlock: () => ({ type: 'UNLOCK_PROJECT' } as UnlockProjectAction)
}

export const reducer: Reducer<ProjectCardState> = (state: ProjectCardState | undefined, incomingAction: Action): ProjectCardState => {
    if (state === undefined) {
        return { imageUrl: "/default-project-card-icon.png", projectName: "Default", projectDescription: "null", isLock: false };
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'LOCK_PROJECT':
            return { imageUrl: state.imageUrl, projectName: "114", projectDescription: state.projectDescription, isLock: true };
        case 'UNLOCK_PROJECT':
            return { imageUrl: state.imageUrl, projectName: "514", projectDescription: state.projectDescription, isLock: false };
        default:
            return state;
    }
}