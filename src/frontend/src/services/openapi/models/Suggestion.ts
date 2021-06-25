/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { User } from './User';

export type Suggestion = {
    id?: string;
    user?: User;
    content?: string | null;
    approved?: boolean;
    approver?: User;
}